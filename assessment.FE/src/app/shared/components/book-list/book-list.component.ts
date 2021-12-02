import { Component, OnInit } from '@angular/core';
import { AlertService } from 'ngx-alerts';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/modules/auth/resources/auth.service';
import { Ibook } from 'src/app/modules/auth/resources/Ibook';
import { IResponse } from 'src/app/modules/auth/resources/IResponse';
import { ISubscriptions } from 'src/app/modules/auth/resources/ISubscriptions';
import { ProgressbarService } from '../../services/progressbar.service';
import { SecretService } from '../../services/secret.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  books!: Ibook[];
  subscriptions!: ISubscriptions[];
  subscriptionsLoaded: boolean = false;
  constructor(
    private secretService: SecretService, 
    public authService: AuthService, 
    private progressService: ProgressbarService,
    private alertService: AlertService) {}

  ngOnInit(): void {
    this.getBooks();
    this.getSubscriptions();
  }

  getSubscriptions() {
    this.subscriptionsLoaded = false;
    this.secretService.getSubscriptions().subscribe(
      res => {
        this.subscriptions = res
        this.subscriptionsLoaded = true;
      },
      error => {
      
      }
    );
  }

  subscriptionExists(id: any) {
    return this.subscriptions.some(function(el) {
      return el.bookId === id;
    }); 
  }

  getBooks() {
    this.secretService.getBooks().subscribe(
      res => {
        this.books = res
      },
      error => {
      
      }
    );
  }

  subscribe(bookId: any) {
    this.alertService.info('Subscribing to book');
    this.progressService.startLoading();
    const subscribeObserver = {
      next: (x: any) => {
        this.getSubscriptions();
        this.progressService.setSuccess();
        this.alertService.success('Subscribed to book');
        this.progressService.completeLoading();
      },
      error: (err: any) => {
        this.progressService.setFailure();
        this.alertService.danger('Unable to Subscribed to book');
        this.progressService.completeLoading();
      },
    };

    this.secretService.Subscribe(bookId).subscribe(subscribeObserver);
  }

  unsubscribe(bookId: any) {
    this.alertService.info('Unsubscribing to book');
    this.progressService.startLoading();
    const subscribeObserver = {
      next: (x: any) => {
        this.getSubscriptions();
        this.progressService.setSuccess();
        this.alertService.success('Unsubscribed to book');
        this.progressService.completeLoading();
      },
      error: (err: any) => {
        this.progressService.setFailure();
        this.alertService.danger('Unable to Unsubscribed to book');
        this.progressService.completeLoading();
      },
    };

    this.secretService.Unsubscribe(bookId).subscribe(subscribeObserver);
  }

}
