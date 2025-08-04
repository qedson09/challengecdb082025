import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimuladorCdbComponent } from './simulador-cdb.component';

describe('SimuladorCdbComponent', () => {
  let component: SimuladorCdbComponent;
  let fixture: ComponentFixture<SimuladorCdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SimuladorCdbComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SimuladorCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
