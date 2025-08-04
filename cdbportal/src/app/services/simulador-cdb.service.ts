import { Injectable } from '@angular/core';
import { ApiUrls } from '../config/api-url.config';
import { RetornoInvestimento } from '../models/retorno-investimento';

@Injectable({ providedIn: 'root' })
export class SimuladorCdbService {
  async calcularRetornoInvestimento(valorInicial: number, meses: number): Promise<RetornoInvestimento> {
    const controller = new AbortController();
    const timeout = setTimeout(() => controller.abort(), 10000); // 10 segundos

    try {
      const response = await fetch(ApiUrls.calcularRetorno, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ valorInicial, meses }),
        signal: controller.signal
      });

      if (!response.ok) {
        const error = await response.json();
        throw new Error(error.message || 'Erro ao calcular retorno.');
      }

      return await response.json();
    } catch (err: any) {
      if (err.name === 'AbortError') {
        throw new Error('Timeout: servidor demorou muito para responder.');
      }
      throw err;
    } finally {
      clearTimeout(timeout);
    }
  }
}
