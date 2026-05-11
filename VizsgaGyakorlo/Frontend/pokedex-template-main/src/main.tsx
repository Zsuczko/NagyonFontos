import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import './exam.css'

import App from './App.tsx'
import PokeContextProvider from './context/PokeContextProvider.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <PokeContextProvider>
      <App />
    </PokeContextProvider>
  </StrictMode>,
)
