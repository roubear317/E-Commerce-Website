import { Photo } from "./Photos"

export interface IProduct {
    id: number
    name: string
    description: string
    price: number
    discount: number
    photo: Photo[]
    rating: number
    reviewsCount: number
    stock: number
    isNew: boolean
    isBestSeller: boolean
    isInWishlist: boolean
    isInCart: boolean
    category: string
  }