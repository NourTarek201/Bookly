import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule, RouterOutlet } from '@angular/router';
import { Button1Component } from './button1/button1.component';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [NavbarComponent,RouterModule],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {

}
