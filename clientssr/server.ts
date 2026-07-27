import { APP_BASE_HREF } from '@angular/common';
import { CommonEngine } from '@angular/ssr/node';

// Disable SSL certificate validation for local development (to allow localhost:6001)
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
import express from 'express';
import compression from 'compression';
import { fileURLToPath } from 'node:url';
import { dirname, join, resolve } from 'node:path';
import bootstrap from './src/main.server';

// The Express app is exported so that it can be used by serverless Functions.
export function app(): express.Express {
  const server = express();
  server.use(compression());
  const serverDistFolder = dirname(fileURLToPath(import.meta.url));
  const browserDistFolder = resolve(serverDistFolder, '../browser');
  const indexHtml = join(serverDistFolder, 'index.server.html');

  const commonEngine = new CommonEngine({
    enablePerformanceProfiler: false,
    allowedHosts: ['localhost', '127.0.0.1']
  });

  server.set('view engine', 'html');
  server.set('views', browserDistFolder);

  // Example Express Rest API endpoints
  // server.get('/api/**', (req, res) => { });

  // Serve robots.txt explicitly as plain text
  server.get('/robots.txt', (req, res) => {
    res.type('text/plain');
    res.sendFile(join(browserDistFolder, 'robots.txt'));
  });

  // Serve static files from /browser
  server.get('*.*', express.static(browserDistFolder, {
    maxAge: '1y',
    immutable: true,
  }));

  // All regular routes use the Angular engine
  server.get('**', (req, res, next) => {
    const { protocol, originalUrl, baseUrl, headers } = req;

    commonEngine
      .render({
        bootstrap,
        documentFilePath: indexHtml,
        url: `${protocol}://${headers.host}${originalUrl}`,
        publicPath: browserDistFolder,
        providers: [
          { provide: APP_BASE_HREF, useValue: baseUrl },
          { provide: 'RESPONSE', useValue: res }
        ],
      })
      .then((html) => res.send(html))
      .catch((err) => next(err));
  });

  return server;
}

function run(): void {

  const port = process.env['PORT'] || 4000;

  // Start up the Node server
  const server = app();
  server.listen(port, () => {
    console.log(`Node Express server listening on http://localhost:${port}`);
  });
}

run();
