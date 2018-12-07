import { Component, ViewChild, EventEmitter, ElementRef, Output, Injector } from "@angular/core"
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { CallServiceProxy, CallDto } from '@shared/service-proxies/service-proxies';
import { finalize } from "rxjs/operators";


@Component({
    selector: "edit-call-modal",
    templateUrl: "./edit-call.component.html"
})

export class EditCallComponent extends AppComponentBase {

    @ViewChild("editCallModal") modal: ModalDirective;
    @ViewChild("modalContent") modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    call: CallDto = null;

    constructor(
        injector: Injector,
        private _callService: CallServiceProxy
    ) {
        super(injector);
    }

    show(id: number): void {
        this._callService.get(id)
            .pipe(finalize(() => {
                this.active = true;
                this.modal.show();
            }))
            .subscribe((result: CallDto) => {
                this.call = result;

            });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        this.saving = true;
        this._callService.update(this.call)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
