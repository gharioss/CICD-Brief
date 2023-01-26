import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SchoolApiService } from './school-api.service';
import { AppComponent } from './app.component';
import { MotivationComponent } from './motivation/motivation.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    MotivationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [SchoolApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
