import { ModuleWithProviders, NgModule } from '@angular/core';
import { CHANGE_TRACKER_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ChangeTrackerConfigModule {
  static forRoot(): ModuleWithProviders<ChangeTrackerConfigModule> {
    return {
      ngModule: ChangeTrackerConfigModule,
      providers: [CHANGE_TRACKER_ROUTE_PROVIDERS],
    };
  }
}
