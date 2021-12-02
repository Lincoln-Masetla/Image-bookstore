import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthLinksComponent } from './auth-links/auth-links.component';
import { AuthRoutingModule } from './resources/auth-routing.module';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    AuthLinksComponent,
  ],
  imports: [CommonModule, AuthRoutingModule, FormsModule, HttpClientModule],
  exports: [
    LoginComponent,
    RegisterComponent,
    AuthLinksComponent,
  ],
})
export class AuthModule {}
