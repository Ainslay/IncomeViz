import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PredictionsComponent } from './containers/predictions/predictions.component';
import { PredictionsListComponent } from './containers/predictions-list/predictions-list.component';
import { PredictionListItemComponent } from './components/prediction-list-item/prediction-list-item.component';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { AddPredictionDialogComponent } from './components/add-prediction-dialog/add-prediction-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    PredictionsComponent,
    PredictionsListComponent,
    PredictionListItemComponent,
    TopBarComponent,
    AddPredictionDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
