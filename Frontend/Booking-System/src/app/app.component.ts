import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';  // <-- import RouterModule here
import { MainComponent } from "./Pages/main/main.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, MainComponent],  // <-- import RouterModule (not RouterOutlet)
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  // <-- fix typo here
})
export class AppComponent {
  title = 'Booking-System';
}
