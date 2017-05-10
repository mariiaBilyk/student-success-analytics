import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { AppRoutingModule, routableComponents } from './app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BudgetComponent } from './budget/budget.component';
import { StudentSucessChartComponent } from './student-sucess/student-sucess-chart.component';
import { StudentSucessComponent } from './student-sucess/student-sucess.component';
import { SemesterSucessFormComponent } from './student-sucess/student-sucess-form.component';
import { SemesterGradesComponent } from './semester-grades/semester-grades.component';
import { SemesterGradesFormComponent } from './semester-grades/semester-grades-form.component';
import { SemesterGradesChartComponent } from './semester-grades/semester-grades-chart.component';
import { GradesService } from './common/services/grades.service';
import { UniversityModulesService } from './common/services/university-modules.service';
import { GradesComponent } from './grades/grades.component';
import { FormComponent } from './grades/form.component';
import { ChartComponent } from './grades/chart.component';
// import { MdButtonModule } from '@angular2-material/button';
import { MaterialModule } from '@angular/material';
import 'hammerjs';  
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {GoogleChart} from 'angular2-google-chart/directives/angular2-google-chart.directive';




@NgModule({
  declarations: [
    AppComponent,
    routableComponents,
    DashboardComponent,
    GradesComponent,
    ChartComponent,
    BudgetComponent,
    StudentSucessComponent,
    StudentSucessChartComponent,
    SemesterSucessFormComponent,
    SemesterGradesComponent,
    SemesterGradesFormComponent,
    SemesterGradesChartComponent,
    FormComponent,
    GoogleChart
  ],
  imports: [
    BrowserModule,
    NoopAnimationsModule,
    ChartsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    AppRoutingModule,
    MaterialModule.forRoot()
  ],
  providers: [GradesService, UniversityModulesService],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
