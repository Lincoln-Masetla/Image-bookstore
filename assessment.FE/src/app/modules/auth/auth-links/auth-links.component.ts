import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../resources/auth.service';

@Component({
  selector: 'app-auth-links',
  templateUrl: './auth-links.component.html',
  styleUrls: ['./auth-links.component.scss'],
})
export class AuthLinksComponent implements OnInit {
  constructor(public authService: AuthService,
    private router: Router ) {}

  ngOnInit(): void {}

  logout() {
    this.authService.logout();
    this.router.navigate(['/login'])
  }
}
