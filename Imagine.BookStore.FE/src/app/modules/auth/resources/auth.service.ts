import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { IUser } from './IUser';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl: string = environment.baseUrl;

  helper = new JwtHelperService();

  currentUser: IUser = {
    username: '',
    email: '',
    role: '',
  };
  constructor(private http: HttpClient) {}

  getAuthStatus() : boolean{
    return localStorage.getItem('token') != null;
  }

  login(model: any): Observable<IUser> {
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: any) => {
        const decodedToken = this.helper.decodeToken(response.token);

        this.currentUser.username = decodedToken.given_name;
        this.currentUser.email = decodedToken.email;
        this.currentUser.role = decodedToken.role;

        localStorage.setItem('token', response.token);
        localStorage.setItem('id', response.id);
        return this.currentUser;
      })
    );
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token') ?? "";
    return !this.helper.isTokenExpired(token);
  }

  logout() {
    this.currentUser = {
      username: '',
      email: '',
      role: '',
    };
    localStorage.removeItem('token');
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'account/register', model);
  }

}
