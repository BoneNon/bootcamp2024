import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPostAddComponent } from './blog-post-add.component';

describe('BlogPostAddComponent', () => {
  let component: BlogPostAddComponent;
  let fixture: ComponentFixture<BlogPostAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BlogPostAddComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlogPostAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
