import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { AuthModule } from './modules/auth/auth.module';
import { NgProgressModule } from 'ngx-progressbar';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertModule } from 'ngx-alerts';
import { BookListComponent } from './shared/components/book-list/book-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    BookListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    NgProgressModule,
    BrowserAnimationsModule,
    AlertModule.forRoot({ maxMessages: 5, timeout: 5000 }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
