/*
**********************************
*           TECZFTP              *
**********************************
#Notas:
<credentials> = credenciais do ftp, deixar nulo se não precisar
<passive> = configuração do modo como ftp opera, usar booleano. Deixar nulo se não souber
<downloads> = lista de downloads a serem feitos
    #ftp = diretorio raiz onde se encontram os arquivos a serem baixados
    #directory = diretorio LOCAL onde os arquivos serão baixados
    #files = arquivos do ftp a serem baixados
    <whenFinished> = array de comandos a serem executados após o download dos arquivos
        #diretivas: 
        $file0 = caminho total do arquivo indice 0 (primeiro arquivo)
        $file2 = caminho total do arquivo indice 2 (terceiro aruivo)
        $directory = caminho do diretorio
<whenDone> = array de comandos a serem executados após o termino de TODOS os downloads
    #diretivas:
    $dw0 = indice do download (não pode ser usado sozinha)
    $dw0$file0 = caminho total do arquivo indice 0 do download indice 0
    $dwN$directory = caminho do diretorio do download indice N
    whenDone = array de comandos que podem ser executados após a conclusão de todos os downloads

*/
{
    credentials: { user: '', pwd: '' }
    ,
    passive: null 
    ,
    downloads: [
        { 
            ftp: 'ftp://ftp.datasus.gov.br/dissemin/publicos/SIASUS/199407_200712/Dados'
            , 
            directory: 'c:\\temp\\SIASUS'
            ,
            files: [
                'PARS9809.dbc',
                'pasc0006.dbc'
            ],
            whenFinished: [
                {
                    program: 'cmd',
                    params: '/C date /t >> $directory\\ftp.log'
                }
                ,
                {
                    program: 'cmd',
                    params: '/C time /t >> $directory\\ftp.log'
                }
                ,
                {
                    program: 'cmd',
                    params: '/C echo $file0 >> $directory\\ftp.log'
                }
                ,
                {
                    program: 'cmd',
                    params: '/C echo $file1 >> $directory\\ftp.log'
                }
            ]
        },
        {
            ftp: 'ftp://ftp.datasus.gov.br/dissemin/publicos/SINAN/DADOS/FINAIS',
            directory: 'c:\\temp\\SINAN',
            files: ['ANIMMG11.dbc', 'ANIMMG13.dbc']
        },
        {
            ftp: 'ftp://ftp.datasus.gov.br/dissemin/publicos/CNES/200508_/doc/',
            directory: 'c:\\temp\\CNES\\DOC'
        }
    ]
    ,
    whenDone : [
        {
            program: 'notepad',
            params: '$dw0$directory\\ftp.log'
        },
        {
            program: 'dbf2dbc',
            params: '"$dw0$file0" "$dw0$directory"'
        }
    ]
}