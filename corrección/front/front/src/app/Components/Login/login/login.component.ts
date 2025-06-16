import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { Router, RouterLink } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import Swal from 'sweetalert2';
import { Login } from '../../../Models/Login/login.models';
import { LoginService } from '../../../Services/Login/login.service';


declare const google: any;

export interface JwtPayloadMe {
  email: string;
  role: string | string[]; // Puede ser uno o varios
  exp: number;
  iat: number; // Ajusta este campo si en tu token el nombre del claim de roles es distinto
}

@Component({
  selector: 'app-login',
  imports: [CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatSnackBarModule,
    RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {//implements OnInit {


  private loginService = inject(LoginService);
  private router = inject(Router);

  public formBuild = inject(FormBuilder);

  hidePassword = true;

  public formLogin: FormGroup = this.formBuild.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  Login() {
    if (this.formLogin.invalid) return;

    const objeto: Login = {
      email: this.formLogin.value.email,
      password: this.formLogin.value.password
    }

    this.loginService.login(objeto).subscribe({
      next: (data) => {
        if (data.isSuccess) {
          localStorage.setItem('token', data.token);
          const decoded = jwtDecode<JwtPayloadMe>(data.token);
          localStorage.setItem('roles', JSON.stringify(decoded.role));
          this.router.navigate(['Citas']);
          Swal.fire({
            icon: "success",
            title: "Exit...",
            text: "Exitoso",
          });
        } else {
          Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "Credenciales incorrectas",


          });
        }
      },
      error: (error) => {
        console.log(error.message);
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "Credenciales incorrectas",
        });
      }
    })
  }

}
