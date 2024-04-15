import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './components/signup/signup.component';
import { SigninComponent } from './components/signin/signin.component';
import { ListComponent } from './components/list/list.component';
import { RealestateComponent } from './components/realestate/realestate.component';

const routes: Routes = [
  { path: 'item', component: RealestateComponent },
  { path: '', component: ListComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
