import React from 'react';

const LoadingSpinner: React.FC = () => {
  return (
    <div className="flex items-center justify-center h-full">
      <div className="animate-spin rounded-full border-t-4 border-blue-500 border-solid border-8 h-16 w-16"></div>
    </div>
  );
};

export default LoadingSpinner;