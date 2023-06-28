import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FeaturesModule } from './features/features/features.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  
  imports: [
    HttpClientModule,
    RouterModule, 
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    FeaturesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }