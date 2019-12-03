import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';

import { AngularmaterialModule } from './material/angularmaterial/angularmaterial.module';

@NgModule({
    imports: [AppModule, ServerModule, ModuleMapLoaderModule, AngularmaterialModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
