import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';

import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddPredictionDialogComponent } from './components/add-prediction-dialog/add-prediction-dialog.component';
import { PredictionListItemComponent } from './components/prediction-list-item/prediction-list-item.component';
import { PredictionTopBarComponent } from './components/prediction-top-bar/prediction-top-bar.component';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { PredictionsListComponent } from './containers/predictions-list/predictions-list.component';
import { PredictionsComponent } from './containers/predictions/predictions.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PredictionDetailsComponent } from './pages/prediction-details/prediction-details.component';
import { ShortTermIncomesListComponent } from './containers/short-term-incomes-list/short-term-incomes-list.component';
import { ShortTermIncomesListItemComponent } from './components/short-term-incomes-list-item/short-term-incomes-list-item.component';
import { LongTermIncomesListComponent } from './containers/long-term-incomes-list/long-term-incomes-list.component';
import { LongTermIncomesListItemComponent } from './components/long-term-incomes-list-item/long-term-incomes-list-item.component';
import { ShortTermExpensesListComponent } from './containers/short-term-expenses-list/short-term-expenses-list.component';
import { ShortTermExpensesListItemComponent } from './components/short-term-expenses-list-item/short-term-expenses-list-item.component';
import { LongTermExpensesListComponent } from './containers/long-term-expenses-list/long-term-expenses-list.component';
import { LongTermExpensesListItemComponent } from './components/long-term-expenses-list-item/long-term-expenses-list-item.component';
import { AddShortTermIncomeDialogComponent } from './dialogs/add-short-term-income-dialog/add-short-term-income-dialog.component';
import { AddShortTermExpenseDialogComponent } from './dialogs/add-short-term-expense-dialog/add-short-term-expense-dialog.component';
import { AddLongTermIncomeDialogComponent } from './dialogs/add-long-term-income-dialog/add-long-term-income-dialog.component';
import { AddLongTermExpenseDialogComponent } from './dialogs/add-long-term-expense-dialog/add-long-term-expense-dialog.component';



@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    PredictionsComponent,
    PredictionsListComponent,
    PredictionListItemComponent,
    TopBarComponent,
    AddPredictionDialogComponent,
    PredictionDetailsComponent,
    PredictionTopBarComponent,
    ShortTermIncomesListComponent,
    ShortTermIncomesListItemComponent,
    LongTermIncomesListComponent,
    LongTermIncomesListItemComponent,
    ShortTermExpensesListComponent,
    ShortTermExpensesListItemComponent,
    LongTermExpensesListComponent,
    LongTermExpensesListItemComponent,
    AddShortTermIncomeDialogComponent,
    AddShortTermExpenseDialogComponent,
    AddLongTermIncomeDialogComponent,
    AddLongTermExpenseDialogComponent,
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
    HttpClientModule,
    MatTabsModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
