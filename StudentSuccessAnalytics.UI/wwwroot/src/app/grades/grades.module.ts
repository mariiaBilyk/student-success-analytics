import { HttpModule } from '@angular/http';
import { ChartsModule } from 'ng2-charts';
import { NgModule } from '@angular/core';

import { GradesComponent } from '../grades/grades.component';
import { FormComponent } from '../grades/form.component';
import { GradesService } from '../common/services/grades.service';

@NgModule({
  declarations: [
    FormComponent,
    GradesComponent
  ],
  imports: [
  ],
  providers: [GradesService],
  bootstrap: [FormComponent]
})
export class GradesModule { }
