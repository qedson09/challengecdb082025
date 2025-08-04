import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SimuladorCdbService } from '../../services/simulador-cdb.service';
import { RetornoInvestimento } from '../../models/retorno-investimento';

@Component({
  selector: 'app-simulador-cdb',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './simulador-cdb.component.html',
  styleUrls: ['./simulador-cdb.component.css']
})
export class SimuladorCdbComponent {
  form: FormGroup;
  resultado: RetornoInvestimento | null = null;
  errorMessage: string | null = null;
  loading = false;

  constructor(private fb: FormBuilder, private service: SimuladorCdbService) {
    this.form = this.fb.group({
      valorInicial: [null, [Validators.required, Validators.min(0.01)]],
      meses: [null, [Validators.required, Validators.min(2)]]
    });
  }

  async calcular(): Promise<void> {
  if (this.form.invalid) return;

  this.loading = true;
  this.resultado = null;
  this.errorMessage = null;

  try {
    this.resultado = await this.service.calcularRetornoInvestimento(
      this.form.value.valorInicial,
      this.form.value.meses
    );
  } catch (err: unknown) {
    if (err instanceof Error) {
      this.errorMessage = err.message;
    } else {
      this.errorMessage = 'Erro desconhecido.';
    }
  } finally {
    this.loading = false;
  }
}

}
