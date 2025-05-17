import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-button1',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './button1.component.html',
  styleUrls: ['./button1.component.css']
})
export class Button1Component {
  @Input() text: string = 'Click';
  @Input() type: string = 'button';
  @Input() classes: string = '';
  @Input() navigateTo?: string;
  constructor(private router: Router) {}

  onClick() {
    if (this.navigateTo) {
      this.router.navigate([this.navigateTo]);
    }
  }
}
