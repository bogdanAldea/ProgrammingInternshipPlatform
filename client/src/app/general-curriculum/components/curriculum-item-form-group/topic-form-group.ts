import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

export class CurriculumItemFormGroup extends FormGroup {
    public readonly title = this.get('title') as FormControl;
    public readonly description = this.get('description') as FormControl;

    public constructor(readonly model?: CurriculumItemGroup, readonly builder: FormBuilder = new FormBuilder()) {
        super(
            builder.group({
                title: [model?.title ?? '', Validators.required],
                description: [model?.description ?? '', Validators.required]
            }).controls
        );
    }
}

export interface CurriculumItemGroup {
    title: string;
    description: string;
}