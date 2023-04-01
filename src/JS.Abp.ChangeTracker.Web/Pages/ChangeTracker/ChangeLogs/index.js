$(function () {
    var l = abp.localization.getResource("ChangeTracker");
	
	var changeLogService = window.jS.abp.changeTracker.changeLogs.changeLog;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ChangeTracker/ChangeLogs/CreateModal",
        scriptUrl: "/Pages/ChangeTracker/ChangeLogs/createModal.js",
        modalClass: "changeLogCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ChangeTracker/ChangeLogs/EditModal",
        scriptUrl: "/Pages/ChangeTracker/ChangeLogs/editModal.js",
        modalClass: "changeLogEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            userId: $("#UserIdFilter").val(),
			userName: $("#UserNameFilter").val(),
			description: $("#DescriptionFilter").val(),
			changeType: $("#ChangeTypeFilter").val(),
			systemID: $("#SystemIDFilter").val(),
			systemName: $("#SystemNameFilter").val()
        };
    };

    var dataTable = $("#ChangeLogsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(changeLogService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('ChangeTracker.ChangeLogs.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('ChangeTracker.ChangeLogs.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    changeLogService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "userId" },
			{ data: "userName" },
			{ data: "description" },
            {
                data: "changeType",
                render: function (changeType) {
                    if (changeType === undefined ||
                        changeType === null) {
                        return "";
                    }

                    var localizationKey = "Enum:ChangeType." + changeType;
                    var localized = l(localizationKey);

                    if (localized === localizationKey) {
                        abp.log.warn("No localization found for " + localizationKey);
                        return "";
                    }

                    return localized;
                }
            },
			{ data: "systemID" },
			{ data: "systemName" }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewChangeLogButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        changeLogService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/change-tracker/change-logs/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'userId', value: input.userId }, 
                            { name: 'userName', value: input.userName }, 
                            { name: 'description', value: input.description }, 
                            { name: 'changeType', value: input.changeType }, 
                            { name: 'systemID', value: input.systemID }, 
                            { name: 'systemName', value: input.systemName }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
    
    
});
