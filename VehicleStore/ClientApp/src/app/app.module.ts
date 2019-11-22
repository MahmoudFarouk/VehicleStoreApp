import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { VehicleStoreComponent } from './vehicle-store/vehicle-store.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { VehicleStoreService } from './vehicle-store/vehicle-store.service';

@NgModule({
  declarations: [
    AppComponent,
    VehicleStoreComponent,
  ],
  exports: [

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: VehicleStoreComponent, pathMatch: 'full' },
    ]),
    NoopAnimationsModule,
  ],
  providers: [VehicleStoreService],
  bootstrap: [AppComponent]
})
export class AppModule { }
