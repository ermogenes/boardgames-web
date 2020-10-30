const iniciar = async () => {
    const response = await fetch('/Boardgames');
    if (response.ok)
    {
        const bgs = await response.json();
        if (bgs.length >= 0)
        {
            const topBg = bgs[0];
            const divTopBg = document.getElementById('bg-top');
            divTopBg.innerHTML = `
                <span>🥇 #1</span>
                <div>${topBg.nome} (${topBg.ano})</div>
                <div>Nota ${topBg.nota}</div>
                <a href="${topBg.bggUrl}"><img src="${topBg.imgUrl}" alt="${topBg.nome}" /></a>
                <div>${topBg.designer}</div>
            `;
        }
        
        if (bgs.length > 1)
        {
            const demaisBgs = bgs.slice(1, 10);
            const divDemaisBgs = document.getElementById('bg-outros');
            let pos = 1;
            demaisBgs.forEach(bg => divDemaisBgs.insertAdjacentHTML('beforeend', 
            `<div>   
                <div class="nota">
                    <span class="posicao">${
                        ++pos === 2 ? '🥈' : pos === 3 ? '🥉' : '#' + pos
                    }</span>
                    nota ${bg.nota}
                </div>
                <div class="nome">${bg.nome} (${bg.ano})</div>
                <a class="link" href="${bg.bggUrl}"><img src="${bg.imgUrl}" alt="${bg.nome}" /></a>
                <div class="designer">${bg.designer}</div>
            </div>
            `));
        }
    }
};

document.addEventListener('DOMContentLoaded', iniciar);