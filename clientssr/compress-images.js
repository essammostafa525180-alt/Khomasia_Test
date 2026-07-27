const sharp = require('sharp');
const path = require('path');
const fs = require('fs');

const imagesDir = path.join(__dirname, 'src', 'assets', 'images');

async function compressImages() {
  // 1. islamic_geometric.webp - decorative pattern
  const geometricInput = path.join(imagesDir, 'islamic_geometric.webp');
  try {
    const geoBuffer = fs.readFileSync(geometricInput);
    const geoInfo = await sharp(geoBuffer).metadata();
    console.log(`islamic_geometric.webp: ${geoInfo.width}x${geoInfo.height}, ${(geoBuffer.length / 1024).toFixed(1)} KB`);
    
    const geoOptBuffer = await sharp(geoBuffer)
      .webp({ quality: 50, effort: 6 })
      .toBuffer();
    
    fs.writeFileSync(geometricInput, geoOptBuffer);
    console.log(`  -> compressed: ${(geoOptBuffer.length / 1024).toFixed(1)} KB`);
    console.log('  -> replaced original');
  } catch (err) {
    console.error('Error optimizing islamic_geometric.webp:', err.message);
  }

  // 2. home-logo.webp - hero image
  const homeLogoInput = path.join(imagesDir, 'home-logo.webp');
  try {
    const homeBuffer = fs.readFileSync(homeLogoInput);
    const homeInfo = await sharp(homeBuffer).metadata();
    console.log(`\nhome-logo.webp: ${homeInfo.width}x${homeInfo.height}, ${(homeBuffer.length / 1024).toFixed(1)} KB`);
    
    const homeOptBuffer = await sharp(homeBuffer)
      .webp({ quality: 30, effort: 6 })
      .toBuffer();
    
    fs.writeFileSync(homeLogoInput, homeOptBuffer);
    console.log(`  -> compressed: ${(homeOptBuffer.length / 1024).toFixed(1)} KB`);
    console.log('  -> replaced original');
  } catch (err) {
    console.error('Error optimizing home-logo.webp:', err.message);
  }

  // 3. hadith-logo.webp - logo generated from original PNG to avoid lock issues on hadith-logo.webp
  const logoInputPng = path.join(imagesDir, 'hadith-logo.png');
  const logoOutput = path.join(imagesDir, 'hadith-logo.webp');
  const logoOptTemp = path.join(imagesDir, 'hadith-logo_opt.webp');
  
  try {
    const logoBuffer = fs.readFileSync(logoInputPng);
    const logoInfo = await sharp(logoBuffer).metadata();
    console.log(`\nhadith-logo.png: ${logoInfo.width}x${logoInfo.height}, ${(logoBuffer.length / 1024).toFixed(1)} KB`);
    
    const logoOptBuffer = await sharp(logoBuffer)
      .resize({ width: 250, withoutEnlargement: true })
      .webp({ quality: 20, effort: 6 })
      .toBuffer();
    
    fs.writeFileSync(logoOutput, logoOptBuffer);
    console.log(`  -> compressed & resized to 250 width: ${(logoOptBuffer.length / 1024).toFixed(1)} KB`);
    console.log('  -> created/replaced hadith-logo.webp');
    
    // Clean up temporary file if it exists
    if (fs.existsSync(logoOptTemp)) {
      try {
        fs.unlinkSync(logoOptTemp);
      } catch (e) {
        // ignore
      }
    }
  } catch (err) {
    console.error('Error optimizing hadith-logo.webp:', err.message);
  }

  // 4. handmade-paper.webp - download and optimize paper texture from transparenttextures.com
  const paperOutput = path.join(imagesDir, 'handmade-paper.webp');
  try {
    console.log('\nDownloading handmade-paper.png from transparenttextures.com...');
    const res = await fetch('https://www.transparenttextures.com/patterns/handmade-paper.png');
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    const paperBuffer = Buffer.from(await res.arrayBuffer());
    
    const paperOptBuffer = await sharp(paperBuffer)
      .webp({ quality: 40, effort: 6 })
      .toBuffer();
    
    fs.writeFileSync(paperOutput, paperOptBuffer);
    console.log(`  -> downloaded & optimized to local WebP: ${(paperOptBuffer.length / 1024).toFixed(1)} KB`);
    console.log('  -> saved as src/assets/images/handmade-paper.webp');
  } catch (err) {
    console.error('Error optimizing handmade-paper.webp:', err.message);
  }

  // 5. arabesque.webp - download and optimize arabesque texture from transparenttextures.com
  const arabesqueOutput = path.join(imagesDir, 'arabesque.webp');
  try {
    console.log('\nDownloading arabesque.png from transparenttextures.com...');
    const res = await fetch('https://www.transparenttextures.com/patterns/arabesque.png');
    if (!res.ok) throw new Error(`HTTP error! status: ${res.status}`);
    const arabesqueBuffer = Buffer.from(await res.arrayBuffer());
    
    const arabesqueOptBuffer = await sharp(arabesqueBuffer)
      .webp({ quality: 40, effort: 6 })
      .toBuffer();
    
    fs.writeFileSync(arabesqueOutput, arabesqueOptBuffer);
    console.log(`  -> downloaded & optimized to local WebP: ${(arabesqueOptBuffer.length / 1024).toFixed(1)} KB`);
    console.log('  -> saved as src/assets/images/arabesque.webp');
  } catch (err) {
    console.error('Error optimizing arabesque.webp:', err.message);
  }

  console.log('\nDone! All images optimized.');
}

compressImages().catch(console.error);

