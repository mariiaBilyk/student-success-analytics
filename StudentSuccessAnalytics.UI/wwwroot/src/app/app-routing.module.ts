import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { GradesComponent } from './grades/grades.component';
import { BudgetComponent } from './budget/budget.component';
import { StudentSucessComponent } from './student-sucess/student-sucess.component';
import { SemesterGradesComponent } from './semester-grades/semester-grades.component';

const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'dashboard' },
	{ path: 'dashboard', component: DashboardComponent },
	{ path: 'grades', component: GradesComponent },
	{ path: 'budget', component: BudgetComponent },
	{ path: 'student_sucess', component: StudentSucessComponent },
	{ path: 'semester_grades', component: SemesterGradesComponent }	
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }

export const routableComponents = [
	GradesComponent,
	BudgetComponent,
	StudentSucessComponent,
	SemesterGradesComponent
];