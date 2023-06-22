import * as cuid from "cuid"

export interface TaskItem {
	id: number
	company: string
	productName: string
	speed: number
	doseControl: string
	isMedical: boolean
	price: number
	quantity: number
}

export interface Task {
	id: string
	items: TaskItem[]
}

export class Basket implements Basket {
	id = cuid();
	items: TaskItem[] = [];
}