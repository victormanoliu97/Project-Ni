import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import {AppComponent} from './app.component';
import {HomeComponent} from './components/home/home.component';
import {PostListComponent} from './components/post-list/post-list.component';
import {PostComponent} from './components/post/post.component';
import {CommentComponent} from './components/comment/comment.component';
import { LoginComponent } from './auth/login/login.component';
import {AppRoutingModule} from './app-routing/app-routing.module';
import {AuthModule} from './auth/auth.module';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        PostListComponent,
        PostComponent,
        CommentComponent,
        LoginComponent,
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        NgbModule,
        AppRoutingModule
    ],
    providers: [AuthModule],
    bootstrap: [AppComponent]
})
export class AppModule {
}
