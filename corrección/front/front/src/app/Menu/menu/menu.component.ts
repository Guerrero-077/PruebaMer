import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterLink, RouterLinkActive } from '@angular/router';

import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';


@Component({
  selector: 'app-menu',
  imports: [MatToolbarModule, MatButtonModule, MatIconModule, RouterLink, MatSidenavModule, MatListModule, RouterLinkActive],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  clearLocalStorage() {
    localStorage.clear();
  }
}
