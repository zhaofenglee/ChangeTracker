import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'ChangeTracker',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44398/',
    redirectUri: baseUrl,
    clientId: 'ChangeTracker_App',
    responseType: 'code',
    scope: 'offline_access ChangeTracker',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44398',
      rootNamespace: 'JS.Abp.ChangeTracker',
    },
    ChangeTracker: {
      url: 'https://localhost:44322',
      rootNamespace: 'JS.Abp.ChangeTracker',
    },
  },
} as Environment;
