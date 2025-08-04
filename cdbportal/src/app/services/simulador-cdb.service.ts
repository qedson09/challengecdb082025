import { Injectable } from '@angular/core';
import { ApiUrls } from '../config/api-url.config';
import { RetornoInvestimentoDto } from '../models/retorno-investimento.dto';

@Injectable({ providedIn: 'root' })
export class SimuladorCdbService {
  async calcularRetornoInvestimento(valorInicial: number, meses: number): Promise<RetornoInvestimentoDto> {
    const response = await fetch(ApiUrls.calcularRetorno, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ valorInicial, meses })
    });

    if (!response.ok) {
      const error = await response.json();
      throw new Error(error.message || 'Erro ao calcular retorno');
    }

    return await response.json();
  }
}
