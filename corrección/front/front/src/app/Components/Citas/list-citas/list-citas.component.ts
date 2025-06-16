import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { Citas } from '../../../Models/Cita/Citas.models';
import { Doctor } from '../../../Models/Doctor/doctor.models';
import { Paciente } from '../../../Models/Paciente/paciente.models';
import { CitaService } from '../../../Services/Cita/cita.service';
import { DoctorService } from '../../../Services/Doctor/doctor.service';
import { PacienteService } from '../../../Services/Paciente/paciente.service';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';


@Component({
  selector: 'app-list-citas',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './list-citas.component.html',
  styleUrl: './list-citas.component.css'
})
export class ListCitasComponent implements OnInit {

  // Inyección de servicios
  private citaService = inject(CitaService);
  private pacienteService = inject(PacienteService);
  private doctorService = inject(DoctorService);
  private fb = inject(FormBuilder);

  // Formulario reactivo
  form!: FormGroup;

  // Datos
  citas: Citas[] = [];
  pacientes: Paciente[] = [];
  doctores: Doctor[] = [];

  // Estado
  isEditMode = false;
  selectedCitaId: number | null = null;

  ngOnInit(): void {
    this.initForm();
    this.getAllCitas();
    this.getAllPacientes();
    this.getAllDoctores();
  }

  private initForm(): void {
    this.form = this.fb.group({
      pacienteId: [null, Validators.required],
      doctorId: [null, Validators.required],
      consultorio: [null, [Validators.required, Validators.min(1)]],
      fechaCita: [null, Validators.required],
      horaCita: [null, Validators.required]
    });
  }


  private getAllCitas(): void {
    this.citaService.getAll().subscribe({
      next: (citas) => {
        console.log('[CITAS] Datos recibidos:', citas);
        this.citas = citas;
      },
      error: (err) => console.error('[CITAS] Error al obtener datos:', err)
    });
  }

  private getAllPacientes(): void {
    this.pacienteService.getAll().subscribe({
      next: (pacientes) => {
        console.log('[PACIENTES] Datos recibidos:', pacientes);
        this.pacientes = pacientes;
      },
      error: (err) => console.error('[PACIENTES] Error al obtener datos:', err)
    });
  }

  private getAllDoctores(): void {
    this.doctorService.getAll().subscribe({
      next: (doctores) => {
        console.log('[DOCTORES] Datos recibidos:', doctores);
        this.doctores = doctores;
      },
      error: (err) => console.error('[DOCTORES] Error al obtener datos:', err)
    });
  }


  save(): void {
    if (this.form.invalid) return;

    const formValue = this.form.value;

    if (this.isEditMode && this.selectedCitaId) {
      this.citaService.update(this.selectedCitaId, formValue).subscribe(() => {
        this.resetForm();
        this.getAllCitas();
      });
    } else {
      this.citaService.create(formValue).subscribe(() => {
        this.resetForm();
        this.getAllCitas();
      });
    }
  }
  edit(cita: Citas): void {
    this.form.patchValue({
      pacienteId: cita.pacienteId,
      doctorId: cita.doctorId,
      consultorio: cita.consultorio,
      fechaCita: cita.fechaCita,
      horaCita: cita.horaCita
    });

    this.selectedCitaId = cita.id;
    this.isEditMode = true;
  }

  delete(id: number): void {
    this.citaService.delete(id).subscribe(() => this.getAllCitas());
  }

  resetForm(): void {
    this.form.reset();
    this.isEditMode = false;
    this.selectedCitaId = null;
  }
}
