import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from 'ngx-alerts';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';
import { AuthService } from '../resources/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  roleOptions: string[] = ['User', 'Api'];

  model: any = {
    username: null,
    email: null,
    password: null,
    role: 'User',
  };
  constructor(
    private progressService: ProgressbarService,
    private alertService: AlertService,
    private authService: AuthService,
    private router: Router  
  ) {}

  ngOnInit(): void {}

  onSubmit() {
    this.alertService.info('Creating new user');
    this.progressService.startLoading();

    const registerObserver = {
      next: () => {
        this.progressService.setSuccess();
        this.alertService.success('Account Created');
        this.progressService.completeLoading();
        this.router.navigate(['/login'])
      },
      error: (err: any) => {
        this.progressService.setFailure();
        this.alertService.danger('Unable to Create Account');
        this.progressService.completeLoading();
      },
    };

    this.authService.register(this.model).subscribe(registerObserver);
  }

  roleChange(value: any) {
    this.model.role = value;
  }

  claimChange(value: any) {
    this.model.claim = value;
  }
}
