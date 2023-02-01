import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

import { EmployeesService } from './services/employees.service';
import { distinctUntilChanged, map } from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  form!: FormGroup;
  title = 'SampleEmployeeWebApp';
  employee!: EmployeeClass[];

  constructor(
    private employeeService: EmployeesService,
    private formBuilder: FormBuilder
  ) {
    this.form = this.formBuilder.group({
      items: this.formBuilder.array([]),
    });
  }

  ngOnInit() {
    this.form = this.formBuilder.group({
      employees: this.formBuilder.array([]),
    });

    this.GetData();
  }

  private GetData() {
    this.employeeService
      .getAllData()
      .subscribe((employees: EmployeeClass[]) => {
        this.form = this.formBuilder.group({
          employees: this.formBuilder.array(
            employees.map((data) => this.generateDatumFormGroup(data))
          ),
        });
      });
  }

  private generateDatumFormGroup(employee: EmployeeClass) {
    return this.formBuilder.group({
      employeeType: this.formBuilder.control({
        value:
          employee.employeeType == 1
            ? 'Salaried'
            : employee.employeeType == 2
            ? 'Manager'
            : 'Hourly',
        disabled: true,
      }),
      id: this.formBuilder.control({ value: employee.id, disabled: true }),
      name: this.formBuilder.control({ value: employee.name, disabled: true }),
      vacationDays: this.formBuilder.control({
        value: employee.vacationDays,
        disabled: false,
      }),
      workDays: this.formBuilder.control({
        value: employee.workDays,
        disabled: false,
      }),
    });
  }

  updateWork(index: number) {
    const form = (<FormArray>this.form.get('employees')).at(index);
    if (form.pristine) {
      return;
    }
    var employeeObj = new EmployeeClass(
      form.get('id')?.value,
      form.get('employeeType')?.value == 'Salaried'
        ? 1
        : form.get('employeeType')?.value == 'Manager'
        ? 2
        : 3,
      form.get('name')?.value,
      form.get('vacationDays')?.value,
      form.get('workDays')?.value
    );

    if (form.get('vacationDays')?.dirty) {
      this.employeeService.UpdateTakeVacation(employeeObj).subscribe({
        next: (response: any) => {
          alert(response.message);
          form.get('vacationDays')?.markAsDirty({ onlySelf: false });
        },
        error: (error) => {
          form
            .get('vacationDays')
            ?.patchValue(error.error.data['vacationDays']);
          alert(error.error.message);
        },
      });
    }

    if (form.get('workDays')?.dirty) {
      this.employeeService.UpdateWork(employeeObj).subscribe({
        next: (response: any) => {
          alert(response.message);
          form.get('vacationDays')?.markAsDirty({ onlySelf: false });
        },
        error: (error) => {
          form.get('workDays')?.patchValue(error.error.data['workDays']);
          alert(error.error.message);
        },
      });
    }
  }

  public get employees() {
    return this.form.get('employees') as FormArray;
  }
}
export class EmployeeClass {
  employeeType: number;
  id: number;
  name: string;
  vacationDays: number;
  workDays: number;

  /**
   *
   */
  constructor(
    id: number,
    employeeType: number,
    name: string,
    vacationDays: number,
    workDays: number
  ) {
    this.id = id;
    this.employeeType = employeeType;
    this.name = name;
    this.vacationDays = vacationDays;
    this.workDays = workDays;
  }
}
