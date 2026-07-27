// Allow self-signed certificates for local API (used by both ng serve SSR and production)
if (typeof process !== 'undefined') {
  process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
}

import { bootstrapApplication, BootstrapContext } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { config } from './app/app.config.server';

const bootstrap = (context: BootstrapContext) => bootstrapApplication(AppComponent, config, context);

export default bootstrap;
