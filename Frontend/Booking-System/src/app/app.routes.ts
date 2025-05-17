import { Routes } from '@angular/router';
import { MainComponent } from './Pages/main/main.component';
import { LoginComponent } from './Pages/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: 'Bookly', pathMatch: 'full' },
  { path: 'Bookly', component: MainComponent },
  { path: 'login', component: LoginComponent }
];
