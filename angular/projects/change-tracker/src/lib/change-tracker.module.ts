import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ChangeTrackerComponent } from './components/change-tracker.component';
import { ChangeTrackerRoutingModule } from './change-tracker-routing.module';

@NgModule({
  declarations: [ChangeTrackerComponent],
  imports: [CoreModule, ThemeSharedModule, ChangeTrackerRoutingModule],
  exports: [ChangeTrackerComponent],
})
export class ChangeTrackerModule {
  static forChild(): ModuleWithProviders<ChangeTrackerModule> {
    return {
      ngModule: ChangeTrackerModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ChangeTrackerModule> {
    return new LazyModuleFactory(ChangeTrackerModule.forChild());
  }
}
