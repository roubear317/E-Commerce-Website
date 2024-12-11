import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeconedSliderComponent } from './seconed-slider.component';

describe('SeconedSliderComponent', () => {
  let component: SeconedSliderComponent;
  let fixture: ComponentFixture<SeconedSliderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SeconedSliderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SeconedSliderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
