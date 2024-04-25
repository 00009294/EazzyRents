import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { ListComponent } from './components/list/list.component';
import { RealEstateComponent } from './components/realestate/realestate.component';
import { MainComponent } from './components/main/main.component';
import { RealestateProfileComponent } from './components/realestate-profile/realestate-profile.component';
import { ProfileComponent } from './components/profile/profile.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AddRealestateComponent } from './components/add-realestate/add-realestate.component';

const routes: Routes = [
  { path: '', component: MainComponent},
  { path: 'profile', component: ProfileComponent},
  { path: 'add-realestate', component: AddRealestateComponent},
  { path: 'realestate-profile/:id', component: RealestateProfileComponent},
  { path: 'item', component: RealEstateComponent },
  { path: 'list', component: ListComponent },
  { path: 'dashboard/:email', component: DashboardComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }
