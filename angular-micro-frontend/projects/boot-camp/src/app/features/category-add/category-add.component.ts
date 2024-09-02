import {
  Component,
  ComponentRef,
  signal,
  ViewContainerRef,
} from '@angular/core';
import { loadRemoteModule } from '@angular-architects/module-federation';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [],
  template: '',
})
export class CategoryAddComponent {
  private componentRef?: ComponentRef<any>;

  private _nameChange?: Subscription;
  constructor(private viewContainer: ViewContainerRef) {}

  async ngOnInit() {
    const module = await loadRemoteModule({
      type: 'module',
      remoteEntry: 'http://localhost:4201/remoteEntry.js',
      exposedModule: './CategoryAdd',
    });
    this.componentRef = this.viewContainer.createComponent(
      module.CategoryAddComponent,
    );
    this.componentRef.instance.name = signal<string>('testtestest');

    this._nameChange = this.componentRef.instance.nameChange.subscribe(
      (name: string) => {
        console.log('nameChange', name);
      },
    );

    console.log('component Ref', this.componentRef);
  }

  ngOnDestroy() {
    this._nameChange?.unsubscribe();
    this.componentRef?.destroy();
  }
}
