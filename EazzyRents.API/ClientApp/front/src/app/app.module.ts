import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignupComponent } from './components/signup/signup.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SigninComponent } from './components/signin/signin.component';
import { AuthInterceptor } from './services/auth.interceptor';
import { ListComponent } from './components/list/list.component';
import { HeaderComponent } from './components/header/header.component';
import { RealEstateComponent } from './components/realestate/realestate.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { MainComponent } from './components/main/main.component';
import { FilterComponent } from './components/filter/filter.component';
import { LocationSortingComponent } from './components/location-sorting/location-sorting.component';
import { RealestateProfileComponent } from './components/realestate-profile/realestate-profile.component';
import { AddressPipe } from './pipes/address.pipe';
import { MapComponent } from './components/map/map.component';
import {  GoogleMapsModule } from '@angular/google-maps';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    SigninComponent,
    ListComponent,
    RealEstateComponent,
    HeaderComponent,
    NavbarComponent,
    SidebarComponent,
    MainComponent,
    FilterComponent,
    LocationSortingComponent,
    AddressPipe,
    RealestateProfileComponent,
    MapComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    GoogleMapsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
