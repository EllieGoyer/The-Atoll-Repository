//Maya ASCII 2018ff09 scene
//Name: GreenCoconut.ma
//Last modified: Tue, Sep 17, 2019 11:04:22 PM
//Codeset: 1252
requires maya "2018ff09";
requires "mtoa" "3.1.2.1";
requires "stereoCamera" "10.0";
requires "mtoa" "3.1.2.1";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201903222215-65bada0e52";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "Coconut";
	rename -uid "41FDA49A-47D1-4EA0-3F75-9BB11942A1B7";
	setAttr ".rp" -type "double3" 5.5873959887589617 26.771414846765097 -0.239563214897764 ;
	setAttr ".sp" -type "double3" 5.5873959887589271 26.771414846765225 -0.23956321489788124 ;
createNode mesh -n "CoconutShape" -p "Coconut";
	rename -uid "590E0B72-44E9-25F7-18ED-6686879C5FB3";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.23492744544339594 0.76566447767059553 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 213 ".uvst[0].uvsp[0:212]" -type "float2" 0.24396624 0.77004576
		 0.24598373 0.76677775 0.065062106 0.75078118 0.061279833 0.75379491 0.06921488 0.74596459
		 0.036830321 0.74367911 0.029438123 0.74581409 0.22328511 0.76748645 0.032716647 0.7508893
		 0.2247407 0.77039647 0.035765275 0.75407422 0.22653197 0.77231884 0.038668513 0.75622356
		 0.228532 0.77364242 0.041335851 0.75755274 0.23022385 0.77458882 0.043918043 0.75836623
		 0.23228173 0.77493286 0.0462704 0.758811 0.23481016 0.7746793 0.048683465 0.75883579
		 0.23677371 0.77454376 0.051553428 0.75822771 0.23892422 0.77372777 0.054514527 0.75744116
		 0.24137636 0.77222395 0.058061838 0.75595796 0.067977548 0.75402105 0.063092113 0.75675035
		 0.074093401 0.74962288 0.024595752 0.74938548 0.029707715 0.75396574 0.033865675
		 0.75676358 0.037394986 0.75858402 0.040531546 0.75981247 0.043349743 0.76047671 0.046174139
		 0.76082993 0.04887116 0.76086426 0.051762581 0.76061499 0.055207849 0.75973284 0.059234142
		 0.75839472 0.070020139 0.75729179 0.064303517 0.75951636 0.076958477 0.75419366 0.021103993
		 0.75361276 0.027522817 0.75717616 0.032473043 0.75938773 0.036497787 0.76080358 0.0399459
		 0.76175869 0.043035984 0.76236689 0.045932591 0.76259744 0.049075246 0.76269102 0.05219245
		 0.76245058 0.055600405 0.76192272 0.0599944 0.76080751 0.071440101 0.76158726 0.06551367
		 0.76276326 0.079015255 0.76003015 0.018310681 0.75918484 0.02569516 0.76128387 0.031238094
		 0.76262176 0.035684004 0.76354218 0.039390445 0.76409268 0.04272759 0.76449895 0.045945466
		 0.7648133 0.049152493 0.76484394 0.052598238 0.76463211 0.056322575 0.76428711 0.060542345
		 0.76365912 0.071975768 0.76583874 0.066003203 0.76616251 0.079669535 0.76565719 0.017215535
		 0.76496565 0.024937585 0.76550698 0.030692533 0.76594472 0.035295501 0.76628196 0.039146602
		 0.76650012 0.04264164 0.76672029 0.045992166 0.76693976 0.049235791 0.76695788 0.052770734
		 0.76692462 0.056602299 0.7666707 0.060936391 0.7664746 0.071655095 0.77052027 0.065823495
		 0.76993227 0.078873932 0.77172518 0.017762616 0.77135599 0.025132731 0.77023709 0.030763611
		 0.76965606 0.035275355 0.7693305 0.039201111 0.76924253 0.04274857 0.76927865 0.046010464
		 0.769256 0.049351811 0.76936191 0.052814662 0.76941907 0.056617558 0.76949155 0.060887218
		 0.76960611 0.070595562 0.77461696 0.065164208 0.77325261 0.077102661 0.77697027 0.019582435
		 0.776842 0.026105627 0.77438295 0.031283155 0.77297759 0.035601154 0.77216852 0.039405704
		 0.77177167 0.042840064 0.77155101 0.046133697 0.77152944 0.049405813 0.77160406 0.052752018
		 0.77172184 0.056461573 0.77204466 0.060561955 0.77252555 0.068966508 0.77849996 0.064183533
		 0.7766037 0.074404776 0.7815783 0.022558466 0.78159022 0.027785078 0.77825379 0.032279268
		 0.77623844 0.036253586 0.77505338 0.039785743 0.77430558 0.043082476 0.77394813 0.046261072
		 0.77385467 0.049349219 0.77386922 0.052576721 0.77410066 0.056099594 0.77463198 0.059911132
		 0.77538109 0.066926122 0.78211391 0.062929153 0.77993417 0.071096539 0.7854203 0.026230261
		 0.78536665 0.029949829 0.78171587 0.033580467 0.779374 0.037078038 0.77793384 0.040332168
		 0.77701485 0.043408483 0.77653325 0.046307474 0.7762754 0.049269378 0.77636659 0.052390873
		 0.77677441 0.055620015 0.77741587 0.059110284 0.77845168 0.23354037 0.76631474 0.038587898
		 0.78868175 0.039398253 0.79133487 0.037233785 0.79092205 0.037653208 0.78970802 0.046785682
		 0.78730786 0.043622881 0.78525507 0.044398099 0.78437352 0.04704836 0.78591102 0.048789561
		 0.78759432 0.048445016 0.78611708 0.050634801 0.78541553 0.051799297 0.78642082 0.057782352
		 0.79089999 0.058998883 0.79169393 0.05625701 0.78473461 0.053521693 0.78273344 0.051079303
		 0.78154886 0.048803389 0.78083396 0.046697617 0.78072727 0.044493347 0.78107321 0.042189449
		 0.78206694 0.039513558 0.78349161 0.036616907 0.78498268 0.034126565 0.78679371 0.032382533
		 0.78925133 0.065183818 0.79031122 0.062811017 0.78789139 0.059850037 0.78609037 0.04559204
		 0.78389859 0.046868652 0.78379178 0.048265517 0.78401995 0.049558222 0.78451633 0.040620774
		 0.7910701 0.039651364 0.78851569 0.056477308 0.79009902 0.043043375 0.78878903 0.052919924
		 0.78984654 0.24663956 0.75639611 0.073794961 0.73800641 0.081483364 0.743155 0.086398005
		 0.74945641 0.089502692 0.75767767 0.090058565 0.7658239 0.088372171 0.77425504 0.085101545
		 0.78109276 0.080515385 0.78658712 0.07524395 0.7905246 0.2472349 0.76225096 0.057917595
		 0.79443181 0.059911013 0.79312444 0.056366563 0.79402578 0.057688475 0.79312003 0.066844344
		 0.79350495 0.060442567 0.79475188 0.056234479 0.79266798 0.052117109 0.79301178 0.048468798
		 0.79183221 0.048692524 0.79021192 0.055586696 0.75238347 0.058176577 0.75020528 0.053134561
		 0.7538873 0.050984055 0.75470328 0.049020499 0.75483882 0.04649207 0.75509238 0.04443419
		 0.75474834 0.042742342 0.75380194 0.040742308 0.75247836 0.038951039 0.75055599 0.037495449
		 0.74764597 0.060849905 0.73655564 0.22261998 0.76351959 0.061445236 0.74241048 0.060194075
		 0.74693727;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 181 ".vt";
	setAttr ".vt[0:165]"  12.98530197 1.71207047 -2.74831104 10.51375675 1.71207047 -5.98560572
		 6.94227886 1.71207047 -7.78217125 2.97823238 1.71207047 -7.78217125 -0.59325242 1.71207047 -5.98560858
		 -3.064797163 1.71207047 -2.74831676 -3.94687629 1.71207047 1.28851986 -3.064799309 1.71207047 5.32535982
		 -0.59325385 1.71207047 8.56264973 2.97823 1.71207047 10.35920906 6.942276 1.71207047 10.35921192
		 10.51375675 1.71207047 8.5626564 12.98530197 1.71207047 5.32535982 13.86738014 1.71207047 1.28852177
		 18.56690025 5.03301239 -4.97166014 14.38858223 5.03301239 -10.44452667 8.35075188 5.03301239 -13.48173523
		 1.64925885 5.03301239 -13.48173523 -4.38857269 5.03301239 -10.44453239 -8.56689262 5.03301239 -4.97166872
		 -10.05812645 5.03301239 1.85288239 -8.56689453 5.03301239 8.67743397 -4.38857889 5.03301239 14.15031147
		 1.64925146 5.03301239 17.18752098 8.35074615 5.03301239 17.18752098 14.38858223 5.03301239 14.15031147
		 18.56690025 5.03301239 8.67743587 20.058130264 5.17012787 0.92147732 21.82312393 9.073631287 -6.79763508
		 16.64196777 9.073631287 -13.58406544 9.15497398 9.073631287 -17.35023689 0.84503925 9.073631287 -17.35023689
		 -6.64195728 9.073631287 -13.58406544 -11.82311916 9.073631287 -6.7976408 -13.67224979 9.073631287 1.66488361
		 -11.82311916 9.073631287 10.12742519 -6.64195871 9.073631287 16.91383934 0.84503078 9.073631287 20.68001175
		 9.15496826 9.073631287 20.68002129 16.64196777 9.073631287 16.91383934 21.82312393 9.073631287 10.12742519
		 23.67225456 9.073631287 0.792243 24.10103989 13.61484146 -8.32832718 18.21833992 13.61484146 -16.033657074
		 9.71757317 13.61484146 -20.30981636 0.28243658 13.61484146 -20.30981636 -8.21833038 13.61484146 -16.033668518
		 -14.10102844 13.61484146 -8.32833862 -16.20056915 13.61484146 1.28005314 -14.10103416 13.61484146 10.88843822
		 -8.21833038 13.61484146 18.59376907 0.28242958 13.61484146 22.86993408 9.71757126 13.61484146 22.86993408
		 18.21833801 13.61484146 18.59378052 24.10103798 13.61484146 10.88843822 26.20057678 13.61484146 0.86414528
		 25.51453018 19.62285805 -9.8227005 19.19650269 19.62285805 -18.098236084 10.066679001 19.62285805 -22.69080734
		 -0.066663712 19.62285805 -22.69080925 -9.19648933 19.62285805 -18.098236084 -15.51452065 19.62285805 -9.82270813
		 -17.76941299 19.62285805 0.49670982 -15.51452827 19.62285805 10.81612206 -9.19649792 19.62285805 19.091644287
		 -0.066670358 19.62285805 23.68421745 10.066673279 19.62285805 23.68421745 19.19649887 19.62285805 19.091653824
		 25.51453018 19.62285805 10.81612873 27.76942444 19.62285805 0.49671555 25.38610077 25.69069099 -10.074625015
		 19.10762978 25.69069099 -18.29834747 10.034959793 25.69069099 -22.86216354 -0.034944091 25.69069099 -22.86216545
		 -9.10761642 25.69069099 -18.29834747 -15.38609314 25.69069099 -10.074625015 -17.62685776 25.69069099 0.18018055
		 -15.38609314 25.69069099 10.43498611 -9.1076231 25.69069099 18.65870667 -0.034953892 25.69069099 23.22253799
		 10.034949303 25.69069099 23.22254753 19.10762596 25.69069099 18.65870667 25.38610077 25.69069099 10.4349947
		 27.62686157 25.69069099 0.18018627 24.00033569336 32.037322998 -9.37754631 18.14865494 32.037322998 -17.04224205
		 9.69270229 32.037322998 -21.29584885 0.30730993 32.037322998 -21.29584885 -8.14864349 32.037322998 -17.042259216
		 -14.00032329559 32.037322998 -9.37755871 -16.088794708 32.037322998 0.18018055 -14.00032997131 32.037322998 9.73792171
		 -8.14865208 32.037322998 17.40261841 0.30730292 32.037322998 21.65621185 9.69269943 32.037322998 21.65621185
		 18.14865112 32.037322998 17.40262222 24.00033187866 32.037322998 9.73792458 26.088802338 32.037322998 0.18018627
		 21.85461044 37.17533875 -8.29817581 16.66375732 37.17533875 -15.097295761 9.16274834 37.17533875 -18.8705349
		 0.83726144 37.17533875 -18.8705349 -6.66374254 37.17533875 -15.097307205 -11.85460281 37.17533875 -8.29818249
		 -13.70718575 37.17533875 0.18018055 -11.85460854 37.17533875 8.65854645 -6.66375256 37.17533875 15.45766544
		 0.83725476 37.17533875 19.2308979 9.16274357 37.17533875 19.2308979 16.6637516 37.17533875 15.45766544
		 21.85461044 37.17533875 8.65854931 23.70718956 37.17533875 0.18018627 18.92472458 41.27584839 -6.82435322
		 14.63619804 41.27584839 -12.44155884 8.43912315 41.27584839 -15.55887699 1.5608871 41.27584839 -15.55887699
		 -4.63618851 41.27584839 -12.44156265 -8.92471313 41.27584839 -6.82435465 -10.45525932 41.27584839 0.18018341
		 -8.92472363 41.27584839 7.18472195 -4.63618946 41.27584839 12.80192852 1.56088209 41.27584839 15.9192543
		 8.43911839 41.27584839 15.9192543 14.63619804 41.27584839 12.80192852 18.92472267 41.27584839 7.18473005
		 20.45526505 41.27584839 0.18018627 10.69499683 48.41159439 -3.65547752 8.94166183 48.41159439 -6.42576694
		 6.40801811 48.41159439 -7.96316051 3.59588313 48.41159439 -7.96316051 1.062237024 48.41159439 -6.42576838
		 -0.69109869 48.41159439 -3.65548134 -1.31686378 48.41159439 -0.20098686 -0.69109958 48.41159439 3.25349998
		 1.062236309 48.41159439 6.023791313 3.59588099 48.41159439 7.56118059 6.40801525 48.41159439 7.56118584
		 8.94166183 48.41159439 6.023794174 10.69499683 48.41159439 3.25350046 11.23301125 48.59170914 -0.16741467
		 4.96025372 0.34057999 1.28852177 4.32766628 49.49041748 -0.20913124 17.68977547 44.28300095 0.011846542
		 16.43308449 44.28300095 5.76303148 12.91195011 44.28300095 10.37512112 7.82374096 44.28300095 12.93464661
		 2.17625976 44.28300095 12.93464661 -2.91194773 44.28300095 10.37511635 -6.43309021 44.28300095 5.76302814
		 -7.68976974 44.28300095 0.011843681 -6.43308115 44.28300095 -5.73933458 -2.91194487 44.28300095 -10.35142899
		 2.17626643 44.28300095 -12.91094875 7.82374287 44.28300095 -12.91094875 12.91195107 44.28300095 -10.35142326
		 16.43308449 44.28300095 -5.73932743 6.71682549 49.1882019 -0.20684052 2.38523412 51.038562775 -2.5005579
		 4.6670084 51.62472916 -2.59423065 4.35442877 50.88585663 -4.14414406 3.20714903 50.88539505 -3.59518909
		 5.6400609 50.88898468 -4.12546158 5.73703098 51.53391266 -2.5970068 7.43588829 51.044651031 -2.47205639
		 6.72175932 50.89169693 -3.55782318 4.67698193 51.8001709 -1.44631767;
	setAttr ".vt[166:180]" 2.14240456 51.36300659 -1.40652752 5.82904243 51.67996979 -1.43557262
		 7.91398621 51.1333847 -1.38223743 1.71826172 51.058292389 1.383564 4.63151264 51.55818939 1.42480946
		 1.98171163 50.77933121 2.75917721 4.61497927 51.35429001 2.76639938 5.96465588 51.42095184 1.4139986
		 5.8549366 51.25152206 2.76078415 7.78280449 50.78684235 2.72391796 8.3554306 50.85393143 1.26588821
		 2.94234371 50.5820694 3.88835049 4.26204491 50.5826149 4.51745272 5.74154472 50.58657455 4.49407148
		 6.98025227 50.58995819 3.84158611;
	setAttr -s 365 ".ed";
	setAttr ".ed[0:165]"  0 1 1 1 2 1 2 3 1 3 4 1 4 5 1 5 6 1 6 7 1 7 8 1 8 9 1
		 9 10 1 10 11 1 11 12 1 12 13 1 13 0 1 14 15 1 15 16 1 16 17 1 17 18 1 18 19 1 19 20 1
		 20 21 1 21 22 1 22 23 1 23 24 1 24 25 1 25 26 1 26 27 1 27 14 1 28 29 1 29 30 1 30 31 1
		 31 32 1 32 33 1 33 34 1 34 35 1 35 36 1 36 37 1 37 38 1 38 39 1 39 40 1 40 41 1 41 28 1
		 42 43 1 43 44 1 44 45 1 45 46 1 46 47 1 47 48 1 48 49 1 49 50 1 50 51 1 51 52 1 52 53 1
		 53 54 1 54 55 1 55 42 1 56 57 1 57 58 1 58 59 1 59 60 1 60 61 1 61 62 1 62 63 1 63 64 1
		 64 65 1 65 66 1 66 67 1 67 68 1 68 69 1 69 56 1 70 71 1 71 72 1 72 73 1 73 74 1 74 75 1
		 75 76 1 76 77 1 77 78 1 78 79 1 79 80 1 80 81 1 81 82 1 82 83 1 83 70 1 84 85 1 85 86 1
		 86 87 1 87 88 1 88 89 1 89 90 1 90 91 1 91 92 1 92 93 1 93 94 1 94 95 1 95 96 1 96 97 1
		 97 84 1 98 99 1 99 100 1 100 101 1 101 102 1 102 103 1 103 104 1 104 105 1 105 106 1
		 106 107 1 107 108 1 108 109 1 109 110 1 110 111 1 111 98 1 112 113 1 113 114 1 114 115 1
		 115 116 1 116 117 1 117 118 1 118 119 1 119 120 1 120 121 1 121 122 1 122 123 1 123 124 1
		 124 125 1 125 112 1 126 127 1 127 128 1 128 129 1 129 130 1 130 131 1 131 132 1 132 133 1
		 133 134 1 134 135 1 135 136 1 136 137 1 137 138 1 138 139 1 139 126 1 0 14 1 1 15 1
		 2 16 1 3 17 1 4 18 1 5 19 1 6 20 1 7 21 1 8 22 1 9 23 1 10 24 1 11 25 1 12 26 1 13 27 1
		 14 28 1 15 29 1 16 30 1 17 31 1 18 32 1 19 33 1 20 34 1 21 35 1 22 36 1 23 37 1 24 38 1
		 25 39 1;
	setAttr ".ed[166:331]" 26 40 1 27 41 1 28 42 1 29 43 1 30 44 1 31 45 1 32 46 1
		 33 47 1 34 48 1 35 49 1 36 50 1 37 51 1 38 52 1 39 53 1 40 54 1 41 55 1 42 56 1 43 57 1
		 44 58 1 45 59 1 46 60 1 47 61 1 48 62 1 49 63 1 50 64 1 51 65 1 52 66 1 53 67 1 54 68 1
		 55 69 1 56 70 1 57 71 1 58 72 1 59 73 1 60 74 1 61 75 1 62 76 1 63 77 1 64 78 1 65 79 1
		 66 80 1 67 81 1 68 82 1 69 83 1 70 84 1 71 85 1 72 86 1 73 87 1 74 88 1 75 89 1 76 90 1
		 77 91 1 78 92 1 79 93 1 80 94 1 81 95 1 82 96 1 83 97 1 84 98 1 85 99 1 86 100 1
		 87 101 1 88 102 1 89 103 1 90 104 1 91 105 1 92 106 1 93 107 1 94 108 1 95 109 1
		 96 110 1 97 111 1 98 112 1 99 113 1 100 114 1 101 115 1 102 116 1 103 117 1 104 118 1
		 105 119 1 106 120 1 107 121 1 108 122 1 109 123 1 110 124 1 111 125 1 112 155 1 113 154 1
		 114 153 1 115 152 1 116 151 1 117 150 1 118 149 1 119 148 1 120 147 1 121 146 1 122 145 1
		 123 144 1 124 143 1 125 142 1 140 0 1 140 1 1 140 2 1 140 3 1 140 4 1 140 5 1 140 6 1
		 140 7 1 140 8 1 140 9 1 140 10 1 140 11 1 140 12 1 140 13 1 132 141 0 139 156 0 142 139 1
		 143 138 1 142 143 1 144 137 1 143 144 1 145 136 1 144 145 1 146 135 1 145 146 1 147 134 1
		 146 147 1 148 133 1 147 148 1 149 132 1 148 149 1 150 131 1 149 150 1 151 130 1 150 151 1
		 152 129 1 151 152 1 153 128 1 152 153 1 154 127 1 153 154 1 155 126 1 154 155 1 155 142 1
		 156 141 0 131 157 1 157 158 1 129 159 1 159 158 1 130 160 1 159 160 1 160 157 1 128 161 1
		 161 162 1 126 163 1 162 163 1 127 164 1 163 164 1 164 161 1 141 165 1 158 165 1 132 166 1
		 157 166 1 166 165 1 156 167 1 162 167 1;
	setAttr ".ed[332:364]" 139 168 1 168 167 1 168 163 1 158 162 1 161 159 1 167 165 1
		 132 169 1 141 170 1 169 170 1 133 171 1 169 171 1 171 172 1 172 170 1 156 173 1 173 174 1
		 138 175 1 174 175 1 139 176 1 175 176 1 176 173 1 134 177 1 171 177 1 135 178 1 177 178 1
		 178 172 1 136 179 1 174 179 1 137 180 1 179 180 1 180 175 1 172 174 1 173 170 1 178 179 1;
	setAttr -s 186 -ch 730 ".fc[0:185]" -type "polyFaces" 
		f 4 0 141 -15 -141
		mu 0 4 199 212 2 3
		f 4 1 142 -16 -142
		mu 0 4 212 211 4 2
		f 4 2 143 -17 -143
		mu 0 4 211 209 178 4
		f 4 3 144 -18 -144
		mu 0 4 5 208 8 6
		f 4 4 145 -19 -145
		mu 0 4 208 207 10 8
		f 4 5 146 -20 -146
		mu 0 4 207 206 12 10
		f 4 6 147 -21 -147
		mu 0 4 206 205 14 12
		f 4 7 148 -22 -148
		mu 0 4 205 204 16 14
		f 4 8 149 -23 -149
		mu 0 4 204 203 18 16
		f 4 9 150 -24 -150
		mu 0 4 203 202 20 18
		f 4 10 151 -25 -151
		mu 0 4 202 201 22 20
		f 4 11 152 -26 -152
		mu 0 4 201 200 24 22
		f 4 12 153 -27 -153
		mu 0 4 200 198 26 24
		f 4 13 140 -28 -154
		mu 0 4 198 199 3 26
		f 4 14 155 -29 -155
		mu 0 4 3 2 27 28
		f 4 15 156 -30 -156
		mu 0 4 2 4 29 27
		f 4 16 157 -31 -157
		mu 0 4 4 178 179 29
		f 4 17 158 -32 -158
		mu 0 4 6 8 31 30
		f 4 18 159 -33 -159
		mu 0 4 8 10 32 31
		f 4 19 160 -34 -160
		mu 0 4 10 12 33 32
		f 4 20 161 -35 -161
		mu 0 4 12 14 34 33
		f 4 21 162 -36 -162
		mu 0 4 14 16 35 34
		f 4 22 163 -37 -163
		mu 0 4 16 18 36 35
		f 4 23 164 -38 -164
		mu 0 4 18 20 37 36
		f 4 24 165 -39 -165
		mu 0 4 20 22 38 37
		f 4 25 166 -40 -166
		mu 0 4 22 24 39 38
		f 4 26 167 -41 -167
		mu 0 4 24 26 40 39
		f 4 27 154 -42 -168
		mu 0 4 26 3 28 40
		f 4 28 169 -43 -169
		mu 0 4 28 27 41 42
		f 4 29 170 -44 -170
		mu 0 4 27 29 43 41
		f 4 30 171 -45 -171
		mu 0 4 29 179 180 43
		f 4 31 172 -46 -172
		mu 0 4 30 31 45 44
		f 4 32 173 -47 -173
		mu 0 4 31 32 46 45
		f 4 33 174 -48 -174
		mu 0 4 32 33 47 46
		f 4 34 175 -49 -175
		mu 0 4 33 34 48 47
		f 4 35 176 -50 -176
		mu 0 4 34 35 49 48
		f 4 36 177 -51 -177
		mu 0 4 35 36 50 49
		f 4 37 178 -52 -178
		mu 0 4 36 37 51 50
		f 4 38 179 -53 -179
		mu 0 4 37 38 52 51
		f 4 39 180 -54 -180
		mu 0 4 38 39 53 52
		f 4 40 181 -55 -181
		mu 0 4 39 40 54 53
		f 4 41 168 -56 -182
		mu 0 4 40 28 42 54
		f 4 183 -57 -183 42
		mu 0 4 41 55 56 42
		f 4 184 -58 -184 43
		mu 0 4 43 57 55 41
		f 4 185 -59 -185 44
		mu 0 4 180 181 57 43
		f 4 186 -60 -186 45
		mu 0 4 45 59 58 44
		f 4 187 -61 -187 46
		mu 0 4 46 60 59 45
		f 4 188 -62 -188 47
		mu 0 4 47 61 60 46
		f 4 189 -63 -189 48
		mu 0 4 48 62 61 47
		f 4 190 -64 -190 49
		mu 0 4 49 63 62 48
		f 4 191 -65 -191 50
		mu 0 4 50 64 63 49
		f 4 192 -66 -192 51
		mu 0 4 51 65 64 50
		f 4 193 -67 -193 52
		mu 0 4 52 66 65 51
		f 4 194 -68 -194 53
		mu 0 4 53 67 66 52
		f 4 195 -69 -195 54
		mu 0 4 54 68 67 53
		f 4 182 -70 -196 55
		mu 0 4 42 56 68 54
		f 4 197 -71 -197 56
		mu 0 4 55 69 70 56
		f 4 198 -72 -198 57
		mu 0 4 57 71 69 55
		f 4 199 -73 -199 58
		mu 0 4 181 182 71 57
		f 4 200 -74 -200 59
		mu 0 4 59 73 72 58
		f 4 201 -75 -201 60
		mu 0 4 60 74 73 59
		f 4 202 -76 -202 61
		mu 0 4 61 75 74 60
		f 4 203 -77 -203 62
		mu 0 4 62 76 75 61
		f 4 204 -78 -204 63
		mu 0 4 63 77 76 62
		f 4 205 -79 -205 64
		mu 0 4 64 78 77 63
		f 4 206 -80 -206 65
		mu 0 4 65 79 78 64
		f 4 207 -81 -207 66
		mu 0 4 66 80 79 65
		f 4 208 -82 -208 67
		mu 0 4 67 81 80 66
		f 4 209 -83 -209 68
		mu 0 4 68 82 81 67
		f 4 196 -84 -210 69
		mu 0 4 56 70 82 68
		f 4 70 211 -85 -211
		mu 0 4 70 69 83 84
		f 4 71 212 -86 -212
		mu 0 4 69 71 85 83
		f 4 72 213 -87 -213
		mu 0 4 71 182 183 85
		f 4 73 214 -88 -214
		mu 0 4 72 73 87 86
		f 4 74 215 -89 -215
		mu 0 4 73 74 88 87
		f 4 75 216 -90 -216
		mu 0 4 74 75 89 88
		f 4 76 217 -91 -217
		mu 0 4 75 76 90 89
		f 4 77 218 -92 -218
		mu 0 4 76 77 91 90
		f 4 78 219 -93 -219
		mu 0 4 77 78 92 91
		f 4 79 220 -94 -220
		mu 0 4 78 79 93 92
		f 4 80 221 -95 -221
		mu 0 4 79 80 94 93
		f 4 81 222 -96 -222
		mu 0 4 80 81 95 94
		f 4 82 223 -97 -223
		mu 0 4 81 82 96 95
		f 4 83 210 -98 -224
		mu 0 4 82 70 84 96
		f 4 225 -99 -225 84
		mu 0 4 83 97 98 84
		f 4 226 -100 -226 85
		mu 0 4 85 99 97 83
		f 4 227 -101 -227 86
		mu 0 4 183 184 99 85
		f 4 228 -102 -228 87
		mu 0 4 87 101 100 86
		f 4 229 -103 -229 88
		mu 0 4 88 102 101 87
		f 4 230 -104 -230 89
		mu 0 4 89 103 102 88
		f 4 231 -105 -231 90
		mu 0 4 90 104 103 89
		f 4 232 -106 -232 91
		mu 0 4 91 105 104 90
		f 4 233 -107 -233 92
		mu 0 4 92 106 105 91
		f 4 234 -108 -234 93
		mu 0 4 93 107 106 92
		f 4 235 -109 -235 94
		mu 0 4 94 108 107 93
		f 4 236 -110 -236 95
		mu 0 4 95 109 108 94
		f 4 237 -111 -237 96
		mu 0 4 96 110 109 95
		f 4 224 -112 -238 97
		mu 0 4 84 98 110 96
		f 4 98 239 -113 -239
		mu 0 4 98 97 111 112
		f 4 99 240 -114 -240
		mu 0 4 97 99 113 111
		f 4 100 241 -115 -241
		mu 0 4 99 184 185 113
		f 4 101 242 -116 -242
		mu 0 4 100 101 115 114
		f 4 102 243 -117 -243
		mu 0 4 101 102 116 115
		f 4 103 244 -118 -244
		mu 0 4 102 103 117 116
		f 4 104 245 -119 -245
		mu 0 4 103 104 118 117
		f 4 105 246 -120 -246
		mu 0 4 104 105 119 118
		f 4 106 247 -121 -247
		mu 0 4 105 106 120 119
		f 4 107 248 -122 -248
		mu 0 4 106 107 121 120
		f 4 108 249 -123 -249
		mu 0 4 107 108 122 121
		f 4 109 250 -124 -250
		mu 0 4 108 109 123 122
		f 4 110 251 -125 -251
		mu 0 4 109 110 124 123
		f 4 111 238 -126 -252
		mu 0 4 110 98 112 124
		f 4 112 253 308 -253
		mu 0 4 112 111 125 126
		f 4 113 254 306 -254
		mu 0 4 111 113 127 125
		f 4 114 255 304 -255
		mu 0 4 113 185 186 127
		f 4 115 256 302 -256
		mu 0 4 114 115 129 128
		f 4 116 257 300 -257
		mu 0 4 115 116 130 129
		f 4 117 258 298 -258
		mu 0 4 116 117 131 130
		f 4 118 259 296 -259
		mu 0 4 117 118 132 131
		f 4 119 260 294 -260
		mu 0 4 118 119 133 132
		f 4 120 261 292 -261
		mu 0 4 119 120 134 133
		f 4 121 262 290 -262
		mu 0 4 120 121 135 134
		f 4 122 263 288 -263
		mu 0 4 121 122 136 135
		f 4 123 264 286 -264
		mu 0 4 122 123 137 136
		f 4 124 265 284 -265
		mu 0 4 123 124 138 137
		f 4 125 252 309 -266
		mu 0 4 124 112 126 138
		f 3 -1 -267 267
		mu 0 3 1 0 139
		f 3 -2 -268 268
		mu 0 3 187 1 139
		f 3 -3 -269 269
		mu 0 3 177 187 139
		f 3 -4 -270 270
		mu 0 3 7 210 139
		f 3 -5 -271 271
		mu 0 3 9 7 139
		f 3 -6 -272 272
		mu 0 3 11 9 139
		f 3 -7 -273 273
		mu 0 3 13 11 139
		f 3 -8 -274 274
		mu 0 3 15 13 139
		f 3 -9 -275 275
		mu 0 3 17 15 139
		f 3 -10 -276 276
		mu 0 3 19 17 139
		f 3 -11 -277 277
		mu 0 3 21 19 139
		f 3 -12 -278 278
		mu 0 3 23 21 139
		f 3 -13 -279 279
		mu 0 3 25 23 139
		f 3 -14 -280 266
		mu 0 3 0 25 139
		f 4 312 -315 316 317
		mu 0 4 140 141 142 143
		f 4 -341 342 343 344
		mu 0 4 144 145 146 147
		f 4 346 348 350 351
		mu 0 4 148 149 150 151
		f 4 319 321 323 324
		mu 0 4 189 191 152 153
		f 4 -285 282 -139 -284
		mu 0 4 137 138 154 155
		f 4 -287 283 -138 -286
		mu 0 4 136 137 155 156
		f 4 -289 285 -137 -288
		mu 0 4 135 136 156 157
		f 4 -291 287 -136 -290
		mu 0 4 134 135 157 158
		f 4 -293 289 -135 -292
		mu 0 4 133 134 158 159
		f 4 -295 291 -134 -294
		mu 0 4 132 133 159 160
		f 4 -297 293 -133 -296
		mu 0 4 131 132 160 161
		f 4 -299 295 -132 -298
		mu 0 4 130 131 161 162
		f 4 -301 297 -131 -300
		mu 0 4 129 130 162 163
		f 4 -303 299 -130 -302
		mu 0 4 128 129 163 164
		f 4 -305 301 -129 -304
		mu 0 4 127 186 192 165
		f 4 -307 303 -128 -306
		mu 0 4 125 127 165 166
		f 4 -309 305 -127 -308
		mu 0 4 126 125 166 167
		f 4 -310 307 -140 -283
		mu 0 4 138 126 167 154
		f 4 -344 353 355 356
		mu 0 4 147 146 168 169
		f 4 -349 358 360 361
		mu 0 4 150 149 170 171
		f 4 -327 -313 328 329
		mu 0 4 172 141 140 173
		f 4 331 -334 334 -322
		mu 0 4 191 194 174 152
		f 4 335 -320 336 314
		mu 0 4 188 191 189 193
		f 4 -338 -332 -336 326
		mu 0 4 190 194 191 188
		f 4 -345 362 -347 363
		mu 0 4 144 147 149 148
		f 4 -359 -363 -357 364
		mu 0 4 170 149 147 169
		f 4 129 315 -317 -314
		mu 0 4 164 163 143 142
		f 4 130 311 -318 -316
		mu 0 4 163 162 140 143
		f 4 126 322 -324 -321
		mu 0 4 167 166 153 152
		f 4 127 318 -325 -323
		mu 0 4 166 165 189 153
		f 4 131 327 -329 -312
		mu 0 4 162 161 173 140
		f 4 280 325 -330 -328
		mu 0 4 161 175 172 173
		f 4 -282 332 333 -331
		mu 0 4 176 154 174 194
		f 4 139 320 -335 -333
		mu 0 4 154 167 152 174
		f 4 128 313 -337 -319
		mu 0 4 165 192 193 189
		f 4 -311 330 337 -326
		mu 0 4 195 176 194 190
		f 4 -281 338 340 -340
		mu 0 4 175 161 145 144
		f 4 132 341 -343 -339
		mu 0 4 161 160 146 145
		f 4 138 349 -351 -348
		mu 0 4 155 154 151 150
		f 4 281 345 -352 -350
		mu 0 4 154 176 148 151
		f 4 133 352 -354 -342
		mu 0 4 160 159 168 146
		f 4 134 354 -356 -353
		mu 0 4 159 158 169 168
		f 4 136 359 -361 -358
		mu 0 4 157 156 171 170
		f 4 137 347 -362 -360
		mu 0 4 156 155 150 171
		f 4 310 339 -364 -346
		mu 0 4 176 195 196 197
		f 4 135 357 -365 -355
		mu 0 4 158 157 170 169;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode transform -s -n "persp";
	rename -uid "534B69A2-4F0F-C435-AEAE-179EB12964A3";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -321.83619265009474 143.59542711582142 -44.253880787357147 ;
	setAttr ".r" -type "double3" -376.53835272959162 252.99999999998161 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "B2AD903F-4069-5D97-BA1B-7D84EB9DB1C1";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 426.93769580636484;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
	setAttr ".ai_translator" -type "string" "perspective";
createNode transform -s -n "top";
	rename -uid "0CCF3211-4AB4-48A3-1A4C-73B0C49A0488";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "74DB3993-49B8-2F45-DA2E-9181929F3A46";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "CEBDA4BA-4E17-5646-ECFB-0D97515495D3";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "0127E926-49AC-E57B-484F-02B6F9CDAECA";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "66E05047-4D00-197E-CEC6-A9B18138F671";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "A8BDCFC3-4E0A-ECFA-1BF5-DD94BDD5F7B0";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode materialInfo -n "materialInfo1";
	rename -uid "FD5548F4-4203-3700-0EFD-EEA96BFEB75F";
createNode shadingEngine -n "lambert2SG";
	rename -uid "110C72A6-4C35-AFE3-2538-9EACC566E48C";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode lambert -n "lambert2";
	rename -uid "20C3344E-4CBA-1553-4ABA-889BF222444A";
createNode checker -n "checker1";
	rename -uid "5ABE41BA-4F53-0514-782A-02AB14502121";
	setAttr ".c1" -type "float3" 0.90719998 0.5686 1 ;
	setAttr ".c2" -type "float3" 0.36019999 0.13 0.6631 ;
createNode place2dTexture -n "place2dTexture1";
	rename -uid "EFD665DE-44EC-67D8-C6F2-A98AAF1690D2";
	setAttr ".re" -type "float2" 4 4 ;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "04E4C591-4366-3C41-FE60-78ADB4B88183";
	setAttr -s 4 ".lnk";
	setAttr -s 4 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "06B33AD1-486C-DE3E-8FBF-2A8FCC533DA5";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "FBF3C178-4A23-DE1E-6641-DBADEA4D1961";
createNode displayLayerManager -n "layerManager";
	rename -uid "32C056C7-4EF6-3EE6-A5B2-FAA603106D40";
createNode displayLayer -n "defaultLayer";
	rename -uid "565D80D7-42FB-D0F5-44A6-CA9A26CDE979";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "9221EA5F-4875-71A5-C8F2-699E1CE1E28A";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "0183C315-4E6C-3FB1-12EE-00B1BAFF9CEB";
	setAttr ".g" yes;
createNode lambert -n "lambert3";
	rename -uid "4F399B74-4F21-22F8-9119-3BA236C71310";
createNode shadingEngine -n "lambert3SG";
	rename -uid "ABBEA6D2-461D-19C8-E700-06A8269E0225";
	setAttr ".ihi" 0;
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "CD97251A-4D86-EFDF-103C-048016F34A7C";
createNode file -n "file1";
	rename -uid "E787A3C0-4982-1DAD-F670-939F7C34BA41";
	setAttr ".ftn" -type "string" "C:/Users/ladya/Desktop/ColorMap (1).png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture2";
	rename -uid "AF4BDA7D-4512-D902-17F9-7680ED605ED4";
createNode script -n "uiConfigurationScriptNode";
	rename -uid "D7507636-4881-5D7F-5A4C-C986D4281CB7";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n"
		+ "            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n"
		+ "            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n"
		+ "            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1205\n            -height 744\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 1\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n"
		+ "            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n"
		+ "            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n"
		+ "            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n"
		+ "            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n"
		+ "                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n"
		+ "                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -autoFitTime 0\n                -snapTime \"integer\" \n"
		+ "                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n"
		+ "                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n"
		+ "                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -autoFitTime 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n"
		+ "\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n"
		+ "                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n"
		+ "                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -editorMode \"default\" \n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n"
		+ "                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -controllers 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n"
		+ "                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1205\\n    -height 744\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1205\\n    -height 744\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "73BC853F-42EE-B9B5-BA09-918F6BD771F4";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode nodeGraphEditorInfo -n "hyperShadePrimaryNodeEditorSavedTabsInfo";
	rename -uid "7116E994-4EB1-A3EE-1696-EE92BC00899B";
	setAttr ".tgi[0].tn" -type "string" "Untitled_1";
	setAttr ".tgi[0].vl" -type "double2" -163.09523161441589 -155.95237475539037 ;
	setAttr ".tgi[0].vh" -type "double2" 159.52380318490313 160.71427932807404 ;
	setAttr -s 4 ".tgi[0].ni";
	setAttr ".tgi[0].ni[0].x" 58.571430206298828;
	setAttr ".tgi[0].ni[0].y" 145.71427917480469;
	setAttr ".tgi[0].ni[0].nvs" 1923;
	setAttr ".tgi[0].ni[1].x" -555.71429443359375;
	setAttr ".tgi[0].ni[1].y" 122.85713958740234;
	setAttr ".tgi[0].ni[1].nvs" 1923;
	setAttr ".tgi[0].ni[2].x" 365.71429443359375;
	setAttr ".tgi[0].ni[2].y" 122.85713958740234;
	setAttr ".tgi[0].ni[2].nvs" 1923;
	setAttr ".tgi[0].ni[3].x" -248.57142639160156;
	setAttr ".tgi[0].ni[3].y" 145.71427917480469;
	setAttr ".tgi[0].ni[3].nvs" 1923;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 4 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 6 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 2 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 2 ".tx";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "lambert2SG.msg" "materialInfo1.sg";
connectAttr "lambert2.msg" "materialInfo1.m";
connectAttr "checker1.msg" "materialInfo1.t" -na;
connectAttr "lambert2.oc" "lambert2SG.ss";
connectAttr "checker1.oc" "lambert2.c";
connectAttr "place2dTexture1.o" "checker1.uv";
connectAttr "place2dTexture1.ofs" "checker1.fs";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "lambert3SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "file1.oc" "lambert3.c";
connectAttr "lambert3.oc" "lambert3SG.ss";
connectAttr "CoconutShape.iog" "lambert3SG.dsm" -na;
connectAttr "lambert3SG.msg" "materialInfo2.sg";
connectAttr "lambert3.msg" "materialInfo2.m";
connectAttr "file1.msg" "materialInfo2.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture2.c" "file1.c";
connectAttr "place2dTexture2.tf" "file1.tf";
connectAttr "place2dTexture2.rf" "file1.rf";
connectAttr "place2dTexture2.mu" "file1.mu";
connectAttr "place2dTexture2.mv" "file1.mv";
connectAttr "place2dTexture2.s" "file1.s";
connectAttr "place2dTexture2.wu" "file1.wu";
connectAttr "place2dTexture2.wv" "file1.wv";
connectAttr "place2dTexture2.re" "file1.re";
connectAttr "place2dTexture2.of" "file1.of";
connectAttr "place2dTexture2.r" "file1.ro";
connectAttr "place2dTexture2.n" "file1.n";
connectAttr "place2dTexture2.vt1" "file1.vt1";
connectAttr "place2dTexture2.vt2" "file1.vt2";
connectAttr "place2dTexture2.vt3" "file1.vt3";
connectAttr "place2dTexture2.vc1" "file1.vc1";
connectAttr "place2dTexture2.o" "file1.uv";
connectAttr "place2dTexture2.ofs" "file1.fs";
connectAttr "lambert3.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[0].dn"
		;
connectAttr "place2dTexture2.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[1].dn"
		;
connectAttr "lambert3SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[2].dn"
		;
connectAttr "file1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[3].dn"
		;
connectAttr "lambert2SG.pa" ":renderPartition.st" -na;
connectAttr "lambert3SG.pa" ":renderPartition.st" -na;
connectAttr "lambert2.msg" ":defaultShaderList1.s" -na;
connectAttr "lambert3.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "place2dTexture2.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "checker1.msg" ":defaultTextureList1.tx" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
// End of GreenCoconut.ma
