import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { RoleServiceProxy, CreateRoleDto, ListResultDtoOfPermissionDto, CallDto, CallServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'create-call-modal',
    templateUrl: './create-call.component.html'
})
export class CreateCallComponent extends AppComponentBase implements OnInit {
    @ViewChild('createCallModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    active: boolean = false;
    saving: boolean = false;

    permissions: ListResultDtoOfPermissionDto = null;
    call: CallDto = null;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    constructor(
        injector: Injector,
        private _callService: CallServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
       
    }

    show(): void {
        this.active = true;
        this.call = new CallDto();
        this.call.init({ isStatic: false });

        this.modal.show();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        var permissions = [];
        $(this.modalContent.nativeElement).find("[name=permission]").each(
            (index: number, elem: Element) => {
                if ($(elem).is(":checked")) {
                    permissions.push(elem.getAttribute("value").valueOf());
                }
            }
        );

        

        this.saving = true;
        this._callService.create(this.call)
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
