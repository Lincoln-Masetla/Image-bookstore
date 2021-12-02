import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from '../resources/auth.service';
import { AlertService } from 'ngx-alerts';
import { ProgressbarService } from 'src/app/shared/services/progressbar.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private progressService: ProgressbarService,
    private alertService: AlertService,
    private router: Router  
  ) {}

  ngOnInit(): void {}

  onSubmit(f: NgForm) {
    this.alertService.info('Check login information');
    this.progressService.startLoading();

    const loginObserver = {
      next: (x: { username: string; }) => {
        this.progressService.setSuccess();
        this.alertService.success('Welcome back ' + x.username);
        this.progressService.completeLoading();
        this.router.navigate([''])
      },
      error: (err: any) => {
        this.progressService.setFailure();
        console.log(err);
        this.alertService.danger('Unable to Login');
        this.progressService.completeLoading();
      },
    };

    this.authService.login(f.value).subscribe(loginObserver);
  }
}
