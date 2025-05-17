import { Component } from '@angular/core';
import { FormComponent } from '../../Shared/form/form.component';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../main/navbar/navbar.component';

@Component({
  selector: 'app-login',
  imports: [FormComponent,NavbarComponent,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

}
