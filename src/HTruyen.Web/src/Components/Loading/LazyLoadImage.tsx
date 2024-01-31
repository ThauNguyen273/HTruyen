import React from 'react';
import { LazyLoadImage as LazyImage } from 'react-lazy-load-image-component';
import 'react-lazy-load-image-component/src/effects/blur.css';

interface LazyLoadImageProps {
  src: string;
  alt: string;
  width: number;
  height: number;
}

const LazyLoadImage: React.FC<LazyLoadImageProps> = ({ src, alt, width, height }) => (
  <LazyImage
    src={src}
    alt={alt}
    width={width}
    height={height}
    className="lazy"
    effect="blur" 
  />
);

export default LazyLoadImage;
