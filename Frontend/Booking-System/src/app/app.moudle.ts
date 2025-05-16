import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { NavbarComponent } from './navbar/navbar.component'; // adjust path as needed

@NgModule({
  declarations: [
    MainComponent,
    NavbarComponent  // ✅ declare it here
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MainComponent
  ]
})
export class MainModule { }
