import { Routes } from '@angular/router';
import { SimuladorCdbComponent } from './components/simulador-cdb.component/simulador-cdb.component';

export const routes: Routes = [
  { path: 'cdb/simulador', component: SimuladorCdbComponent },
  { path: '', redirectTo: 'cdb/simulador', pathMatch: 'full' }
];
