import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Ibook } from 'src/app/modules/auth/resources/Ibook';
import { IResponse } from 'src/app/modules/auth/resources/IResponse';
import { ISubscriptions } from 'src/app/modules/auth/resources/ISubscriptions';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SecretService {
  baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) {}

  getBooks(): Observable<Ibook[]> {
    return this.http.get(this.baseUrl + 'bookStore',
    this.getHttpOptions())
      .pipe(map((res: any) => res));
  }

  getSubscriptions(): Observable<ISubscriptions[]> {
    return this.http.get(this.baseUrl + 'bookStore/subscriptions/'+localStorage.getItem('id'),
    this.getHttpOptions())
      .pipe(map((res: any) => res));
  }

  Subscribe(bookId: any): Observable<ISubscriptions> {
    return this.http.post(this.baseUrl + 'bookStore/subscriptions/create', { userId: localStorage.getItem('id'), bookId: bookId},
    this.getHttpOptions()).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  Unsubscribe(bookId: any): Observable<ISubscriptions> {
    return this.http.post(this.baseUrl + 'bookStore/subscriptions/delete', { userId: localStorage.getItem('id'), bookId: bookId},
    this.getHttpOptions()).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token'),
      }),
    };

    return httpOptions;
  }
}
