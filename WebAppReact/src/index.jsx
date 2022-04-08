import React from 'react';
import { createRoot } from 'react-dom/client';
import Root from './components/Root';

const root = createRoot(document.body);

root.render(
    <React.StrictMode>
        <Root />
    </React.StrictMode>
);
